﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.Engine.Base.Objects;
using BH.oM.Common.Materials;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using System;
using System.Collections.Generic;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** BHoM Adapter Interface                    ****/
        /***************************************************/
        
        //Compares nodes by distance (down to 3 decimal places -> mm)
        //Compares Materials, SectionProprties, LinkConstraints, and Property2D by name
        //Add/remove any type in the dictionary below that you want (or not) a specific comparison method for

        private void SetupComparers()
        {
            AdapterComparers = new Dictionary<Type, object>
            {
                {typeof(Node), new BH.Engine.Structure.NodeDistanceComparer(3) },   //The 3 in here sets how many decimal places to look at for node merging. 3 decimal places gives mm precision
                {typeof(ISectionProperty), new BHoMObjectNameOrToStringComparer() },
                {typeof(Material), new BHoMObjectNameComparer() },
                {typeof(LinkConstraint), new BHoMObjectNameComparer() },
                {typeof(ISurfaceProperty), new BHoMObjectNameComparer() },
            };
        }


        /***************************************************/
    }
}