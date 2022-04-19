using System;
using System.Collections.Generic;
using System.Text;
using SoruTest.Core.Entities;

namespace SoruTest.Entities.Concrete
{
    public class CorrectAnswer:IEntity
    {
        public int Id { get; set; }
        public int OptionId { get; set; }
        public string Correct { get; set; }
    }
}
