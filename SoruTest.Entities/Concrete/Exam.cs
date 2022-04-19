using SoruTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Entities.Concrete
{
    public class Exam:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
