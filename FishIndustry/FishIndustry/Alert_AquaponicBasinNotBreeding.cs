﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;   // Always needed
using RimWorld;      // RimWorld specific functions are found here
using Verse;         // RimWorld universal objects are here
//using Verse.AI;    // Needed when you do something with the AI
//using Verse.Sound; // Needed when you do something with the Sound

namespace FishIndustry
{
    /// <summary>
    /// Alert_AquacultureBasinNotBreeding class.
    /// </summary>
    /// <author>Rikiki</author>
    /// <permission>Use this code as you want, just remember to add a link to the corresponding Ludeon forum mod release thread.
    /// Remember learning is always better than just copy/paste...</permission>
    public class Alert_AquacultureBasinNotBreeding : Alert_High
    {
        public override AlertReport Report
        {
            get
            {
                foreach (Building_AquacultureBasin aquacultureBasin in Find.ListerBuildings.AllBuildingsColonistOfClass<Building_AquacultureBasin>())
                {
                    if (aquacultureBasin.powerComp.PowerOn
                        && (aquacultureBasin.IsForbidden(Faction.OfColony) == false)
                        && (aquacultureBasin.breedingSpeciesDef == null)
                        && (aquacultureBasin.microFungusRemainingDurationInTicks == 0))
                    {
                        return AlertReport.CulpritIs(aquacultureBasin);
                    }
                }
                return AlertReport.Inactive;
            }
        }
        public Alert_AquacultureBasinNotBreeding()
        {
            this.baseLabel = "Idle aquaculture basin";
            this.baseExplanation = "You have an idle aquaculture basin.\n\nYou should supply it some fish eggs to start breeding.\n\nUse the bills tab to order it and check you have an available fisher.";
        }
    }
}