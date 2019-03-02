﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_main
{
    public abstract class PrivateEffects
    {
        //Абстрактый класс личных эффектов, влияющих на скилл и производительность
        public abstract void HaveEffect(Developer buddy);
        public abstract int getDuration();
    }

    public class Depression : PrivateEffects
    {
        private int duration,power;
        private bool isActive = false;
        public Depression(int duration)
        {
            this.duration = duration;
        }

        public override int getDuration()
        {
            return duration;
        }
        //Депрессия оказывает влияние, понижая характеристики на половину минимальной, если речь идет о программисте, и половину, если о других (творческие профессии, все дела)
        public override void HaveEffect(Developer buddy)
        {
            if (!isActive){
                if (buddy.getCodeskill() == 0) power = -buddy.getDesignskill() / 2; else power = -(Math.Min(buddy.getCodeskill(), buddy.getDesignskill()) / 2);
                buddy.set_AddEffSkill(power);
                isActive = true;
                duration--;
            } else
            {
                if (duration != 0) duration--; else
                {
                    buddy.set_AddEffSkill(0);
                }
                }
            }

            
        }
    }