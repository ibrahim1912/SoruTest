using System;
using System.Collections.Generic;
using System.Text;
using SoruTest.Core.Entities;

namespace SoruTest.Entities.Concrete
{
    public class Option:IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool CorrectOption { get; set; }
    }
}
