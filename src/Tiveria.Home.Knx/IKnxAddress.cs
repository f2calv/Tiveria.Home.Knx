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

using Tiveria.Home.Knx.Primitives;

namespace Tiveria.Home.Knx
{
    /// <summary>
    /// Interface common to both Individual and Group Adresses in Knx.
    /// </summary>
    public interface IKnxAddress : ICloneable, IKnxDataElement
    {
        /// <summary>
        /// Raw representation of the address
        /// </summary>
        ushort RawAddress { get; }

        /// <summary>
        /// Type of the address
        /// </summary>
        AddressType AddressType { get; }

        /// <summary>
        /// Checks if an address is a <see cref="GroupAddress"/> or a <see cref="IndividualAddress"/>
        /// </summary>
        /// <returns>True in case of a <see cref="GroupAddress"/></returns>
        bool IsGroupAddress();

        /// <summary>
        /// Checks if an address is a <see cref="GroupAddress"/> or a <see cref="IndividualAddress"/>
        /// </summary>
        /// <returns>True in case of a <see cref="IndividualAddress"/></returns>
        bool IsIndividualAddress();

        /// <summary>
        /// Checks whether the provided Address is an <see cref="IndividualAddress"/> for broadcast
        /// </summary>
        /// <returns>True in case of a broadcast message</returns>
        bool IsBroadcast();
    }
}
