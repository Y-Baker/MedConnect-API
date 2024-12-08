﻿using Medical.Data.Interface;
using Medical.Data.UnitOfWorks;
using Medical.DTOs.AppointmentDTOs;
using Medical.Models;
using Medical.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IUnitOfWork _unit;
    private readonly UserManager<AppUser> userManager;

    public AppointmentsController(IUnitOfWork unit, UserManager<AppUser> userManager)
    {
        _unit = unit;
        this.userManager = userManager;
    }

    [Authorize(Roles = "Patient")]
    [HttpPost]
    public async Task<IActionResult> BookAppointment([FromBody] BookAppointmentDTO appointmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (User.Identity?.Name == null)
            return Unauthorized();
        
        Patient? patient = await userManager.FindByNameAsync(User.Identity.Name) as Patient;
        if (patient == null)
            return NotFound(new { message = "Patient not found" });

        var appointment = new Appointment
        {
            Date = appointmentDto.Date,
            Time = appointmentDto.Time,
            Reason = appointmentDto.Reason,
            PatientId = patient.Id,
            DoctorId = appointmentDto.DoctorId,
            Status = Status.Waiting
        };

        //TODO: Validate Appoinment (Date, Time) => Date (1 -> 30days) Time (in working hours(shift) && not in holidays, not taken before)
        await _unit.AppointmentRepository.Add(appointment);
        await _unit.NotificationRepository.Add(patient.Id, "Appointment booked successfully waiting for confirmation");
        await _unit.Save();
    
        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var appointment = await _unit.AppointmentRepository.GetById(id);

        if (appointment == null)
            return NotFound(new { message = "Appointment not found" });

        var appointmentDto = new AppointmentDetailsDTO
        {
            Id = appointment.Id,
            Date = appointment.Date,
            Time = appointment.Time,
            Status = appointment.Status,
            Reason = appointment.Reason,
            PatientId = appointment.PatientId,
            DoctorId = appointment.DoctorId,
            ProviderId = appointment.Doctor?.ProviderId
        };

        return Ok(appointmentDto);
    }

    [HttpPut("{id}/reschedule")]
    public async Task<IActionResult> RescheduleAppointment(int id, [FromBody] RescheduleAppointmentDTO rescheduleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var appointment = await _unit.AppointmentRepository.GetById(id);

        if (appointment == null)
            return NotFound(new { message = "Appointment not found" });

        appointment.Date = rescheduleDto.NewDate;
        appointment.Time = rescheduleDto.NewTime;
        appointment.Status = Status.Resceduled;

        //TODO: Validate Appoinment (Date, Time) => Date (1 -> 30days) Time (in working hours(shift) && not in holidays, not taken before)
        await _unit.AppointmentRepository.Update(appointment);
        await _unit.Save();

        return Ok(new { message = "Appointment rescheduled successfully" });
    }

    [Authorize(Roles = "Patient")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelAppointment(int id)
    {
        if (User.Identity?.Name == null)
            return Unauthorized();
        
        Patient? patient = await userManager.FindByNameAsync(User.Identity.Name) as Patient;
        if (patient == null)
            return NotFound(new { message = "Patient not found" });
        
        var appointment = await _unit.AppointmentRepository.GetById(id);

        if (appointment == null)
            return NotFound(new { message = "Appointment not found" });

        if (appointment.PatientId != patient.Id)
            return Unauthorized(new { message = "You are not authorized to cancel this appointment" });

        await _unit.AppointmentRepository.Delete(appointment);
        await _unit.NotificationRepository.Add(patient.Id, "Appointment canceled successfully");
        await _unit.Save();

        return Ok(new { message = "Appointment canceled successfully" });
    }

    [Authorize(Roles = "Provider")]
    [HttpPut("{id}/confirm")]
    public async Task<IActionResult> ConfirmAppointment(int id)
    {
        var appointment = await _unit.AppointmentRepository.GetById(id);
        if (appointment == null)
            return NotFound(new { message = "Appointment not found" });

        if (appointment.Status != Status.Waiting)
            return BadRequest(new { message = "This appointment is not in the waiting list" });

        appointment.Status = Status.Confirmed;

        await _unit.AppointmentRepository.Update(appointment);
        await _unit.Save();

        await _unit.NotificationRepository.Add(appointment.PatientId, "Your appointment has been confirmed");
        await _unit.Save();

        return Ok(new { message = "Appointment confirmed successfully" });
    }

}
