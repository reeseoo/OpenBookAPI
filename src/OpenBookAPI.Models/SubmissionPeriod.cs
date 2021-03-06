﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBookAPI.Models
{
    public class SubmissionPeriod
    {
        /// <summary>
        /// Id of this submission period
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of the parent Story
        /// </summary>
        public Guid StoryId { get; set; }

        /// <summary>
        /// the position of the chosen snippet in the story
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// the status of the submissionperiod
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SubmissionPeriodStatus Status { get; set; }
        /// <summary>
        /// Datetime that the submissionperiod started
        /// </summary>
        public DateTime StartDate { get; set; }
    }

    public enum SubmissionPeriodStatus
    {
        Open = 0,
        Closed = 1
    }
}
