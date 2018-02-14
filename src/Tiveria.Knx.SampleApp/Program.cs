﻿using System;
using System.Net;
using Tiveria.Knx;
using Tiveria.Knx.IP;
using Tiveria.Common.Extensions;
using Tiveria.Knx.IP.Utils;
using Tiveria.Knx.IP.ServiceTypes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = IPAddress.Parse("192.168.2.101"); // 230
            ushort port = 3671;

            var con = new Tiveria.Knx.IP.TunnelingConnection(ip, port, IPAddress.Parse("192.168.2.112"), 3671);
            con.DataReceived += Con_DataReceived;
            con.FrameReceived += Con_FrameReceived;
            Console.WriteLine("Hello World!");

            con.ConnectAsync().Wait();
            Console.ReadLine();
            con.Stop();
        }

        private static void Con_FrameReceived(object sender, FrameReceivedEventArgs e)
        {
            Console.WriteLine($"Frame received. Type: {e.Frame.ServiceType}");
            if(e.Frame.ServiceType.ServiceTypeIdentifier == ServiceTypeIdentifier.TUNNELING_REQ)
            {
                //var req = (TunnelingRequest)e.Frame.ServiceType;
                //req.CemiFrame.
            }
        }

        private static void Con_DataReceived(object sender, Tiveria.Knx.IP.DataReceivedArgs e)
        {
            Console.WriteLine(e.Data.ToHexString());
        }
    }
}
