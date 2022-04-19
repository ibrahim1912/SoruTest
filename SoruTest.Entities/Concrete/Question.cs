using System;
using System.Collections.Generic;
using System.Text;
using SoruTest.Core.Entities;

namespace SoruTest.Entities.Concrete
{
    public class Question:IEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }

    }
}
