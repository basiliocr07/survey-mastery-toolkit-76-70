
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.WebMvc.Models
{
    public class SurveyViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; }

        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

        public DateTime CreatedAt { get; set; }
        
        public int Responses { get; set; }
        
        public int CompletionRate { get; set; }

        public DeliveryConfigViewModel DeliveryConfig { get; set; } = new DeliveryConfigViewModel();
    }

    public class SurveyListViewModel
    {
        public List<SurveyViewModel> Surveys { get; set; } = new List<SurveyViewModel>();
    }

    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Question type is required")]
        public string Type { get; set; }
        
        public bool Required { get; set; }
        
        public List<string> Options { get; set; } = new List<string>();
    }

    public class CreateSurveyViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; }

        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

        public DeliveryConfigViewModel DeliveryConfig { get; set; } = new DeliveryConfigViewModel();
    }

    public class DeliveryConfigViewModel
    {
        public string Type { get; set; } = "Manual";
        
        public List<string> EmailAddresses { get; set; } = new List<string>();
        
        public ScheduleViewModel Schedule { get; set; } = new ScheduleViewModel();
        
        public TriggerViewModel Trigger { get; set; } = new TriggerViewModel();
    }

    public class ScheduleViewModel
    {
        public string Frequency { get; set; } = "monthly";
        
        public int DayOfMonth { get; set; } = 1;
        
        public int? DayOfWeek { get; set; }
        
        public string Time { get; set; } = "09:00";
        
        public DateTime? StartDate { get; set; }
    }

    public class TriggerViewModel
    {
        public string Type { get; set; } = "ticket-closed";
        
        public int DelayHours { get; set; } = 24;
        
        public bool SendAutomatically { get; set; } = false;
    }
}
