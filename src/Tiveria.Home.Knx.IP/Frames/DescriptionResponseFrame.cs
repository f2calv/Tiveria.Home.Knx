﻿/*
    Tiveria.Home.Knx - a .Net Core base KNX library
    Copyright (c) 2018-2022 M. Geissler

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

    Linking this library statically or dynamically with other modules is
    making a combined work based on this library. Thus, the terms and
    conditions of the GNU General Public License cover the whole
    combination.
*/

using Tiveria.Common.IO;
using Tiveria.Home.Knx.IP.Enums;
using Tiveria.Home.Knx.IP.Structures;

namespace Tiveria.Home.Knx.IP.Frames
{
    public class DescriptionResponseFrame : FrameBase
    {
        public override ServiceTypeIdentifier ServiceTypeIdentifier => ServiceTypeIdentifier.DescriptionResponse;
        public DeviceInfoDIB DeviceInfoDIB { get; init; }
        public ServiceFamiliesDIB ServiceFamiliesDIB { get; init; }
        public OtherDIB? OtherDIB { get; init; }

        public DescriptionResponseFrame(FrameHeader frameHeader, DeviceInfoDIB deviceInfoDIB, ServiceFamiliesDIB serviceFamiliesDIB, OtherDIB? otherDIB)
            : base(frameHeader, ServiceTypeIdentifier.DescriptionResponse,  deviceInfoDIB.Size + serviceFamiliesDIB.Size + (otherDIB == null ? 0 : otherDIB.Size))
        {
            DeviceInfoDIB = deviceInfoDIB;
            ServiceFamiliesDIB = serviceFamiliesDIB;
            OtherDIB = otherDIB;
        }

        public DescriptionResponseFrame(Hpai serviceEndpoint, DeviceInfoDIB deviceInfoDIB, ServiceFamiliesDIB serviceFamiliesDIB, OtherDIB? otherDIB)
            : this(new FrameHeader(ServiceTypeIdentifier.DescriptionResponse, serviceEndpoint.Size + deviceInfoDIB.Size + serviceFamiliesDIB.Size + (otherDIB == null ? 0 : otherDIB.Size)),
                   deviceInfoDIB, serviceFamiliesDIB, otherDIB) 
        { }
    }
}