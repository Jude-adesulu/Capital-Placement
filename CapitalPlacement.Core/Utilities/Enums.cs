using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Utilities
{
    public class Enums
    {
        public enum Skill
        {
            UI = 1,
            Social_Media = 2,
            UX = 3,
            Graphic_Design = 4,
            Content_Writing = 5,
            SEO = 6
        }

        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        public enum Qualification
        {
            High_School = 1,
            College = 2,
            Graduate = 3,
            University = 4,
            Masters = 5,
            Ph_D = 6,
            Any = 7
        }

        public enum ProgramType
        {
            Internship = 1,
            Job = 2,
            Training = 3,
            Master_Class = 4,
            Webinar = 5,
            Course = 6,
            Live_Seminar = 7,
            Volunteering = 8,
            Others = 9
        }

        public enum QuestionType
        {
            Paragraph = 1,
            ShortAnswer = 2,
            YesOrNo = 3,
            Dropdown = 4,
            MultipleChoice = 5,
            Date = 6,
            Number = 7,
            VideoQuestion = 8,
            FileUpload = 9
        }

        public enum StageType
        {
            Applied = 1,
            VideoInterview = 2,
            Shortlisting = 3,
            Placement = 4
        }

    }
}
