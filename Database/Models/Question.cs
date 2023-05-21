﻿using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Model
{
    public class Question
    {

        public Guid Id { get; set; }

        [EncryptColumn]
        public string Content { get; set; }

        public virtual List<Answer> Answers { get; set; }
     
    }
}
