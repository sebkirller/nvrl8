﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nvrl8_ws.Model
{
    public class Settings
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string GoTime { get; set; }
        public string AwakeTime { get; set; }
        public string OriginX { get; set; }
        public string OriginY { get; set; }
        public int UseBus { get; set; }
        public string ArrivalTime { get; set; }

        public Settings(int id, string origin, string destination, string originY, string originX, int useBus, string goTime, string awakeTime, string arrivalTime)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            OriginX = originX;
            OriginY = originY;
            UseBus = useBus;
            GoTime = goTime;
            AwakeTime = awakeTime;
            ArrivalTime = arrivalTime;
        }

        public Settings()
        {

        }
    }
}
