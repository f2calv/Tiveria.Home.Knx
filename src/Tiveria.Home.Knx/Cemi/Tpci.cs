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
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

    Linking this library statically or dynamically with other modules is
    making a combined work based on this library. Thus, the terms and
    conditions of the GNU Lesser General Public License cover the whole
    combination.
*/

using Tiveria.Common.IO;
using Tiveria.Home.Knx.Exceptions;

namespace Tiveria.Home.Knx.Cemi
{
    /// <summary>
    ///
    /// <code>
    /// +-----------------------------------------------------------------------+
    /// |          NPDU Byte 1: 6 bit TPCI & 2 bit APCI                         |
    /// +--------+--------+--------+--------+--------+--------+--------+--------+
    /// | bit 0  | bit 1  | bit 2  | bit 3  | bit 4  | bit 5  | bit 6  | bit 7  |
    /// +--------+--------+--------+--------+--------+--------+--------+--------+
    /// |                       TPCI Data                     |    APCI/ TPCI   |
    /// +--------+--------+--------+--------+--------+--------+--------+--------+
    /// | Packet | Sequ-  |          Sequence Number          |  TPCI:          |
    /// | Type   | encing |                                   |    ControlType  |
    /// | Flag   | Flag   |                                   |                 |
    /// +--------+--------+--------+--------+--------+--------+--------+--------+
    /// </code>
    /// 
    /// </summary>
    /// 
    public class Tpci
    {
        public PacketType PacketType { get; set; }
        public SequenceType SequenceType { get; set; }
        public byte SequenceNumber { get; set; }
        public ControlType ControlType { get; set; }
        public Tpci(PacketType packetType = PacketType.Data, SequenceType sequenceType = SequenceType.UnNumbered, byte sequenceNumber = 0, ControlType controlType = ControlType.None)
        {
            PacketType = packetType;
            SequenceType = sequenceType;
            SequenceNumber = (byte)(sequenceNumber & 0b0000_1111);
            ControlType = controlType;
        }

        public Tpci(byte raw)
        {
            PacketType = (PacketType)(raw & 0b1_0000000);
            SequenceType = (SequenceType)(raw & 0b0_1_000000);
            SequenceNumber = (SequenceType == SequenceType.Numbered) ? 
                (byte) ((raw & 0b00_1111_00) >> 2) : (byte)0;
            ControlType = (PacketType == PacketType.Control) ? 
                (ControlType)(raw & 0b000000_11) : ControlType.None;
        }

        public byte ToByte()
        {
            var raw = (byte)PacketType;
            raw |= (byte)SequenceType;
            if (SequenceType == SequenceType.Numbered)
                raw |= (byte)(SequenceNumber << 2 & 0b00_1111_00);
            if (PacketType == PacketType.Control)
                raw |= (byte)ControlType;
            return raw;
        }

        public static Tpci Parse(byte data)
        {
            return new Tpci(data);
        }
    }
}
