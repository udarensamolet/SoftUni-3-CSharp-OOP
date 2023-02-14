﻿namespace P04.Recharge.After.Models
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            workingHours += hours;
        }
    }
}