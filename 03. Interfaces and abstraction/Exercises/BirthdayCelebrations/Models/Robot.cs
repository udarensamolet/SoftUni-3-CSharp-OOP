﻿using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Robot : IIDentifiable, IRobot
    {
        public Robot(string model, string id) 
        {
            Model = model;
            Id = id;
        }
        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}
