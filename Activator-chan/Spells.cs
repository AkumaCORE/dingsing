﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Activator_chan
{
    class Spells
    {
        public static Spell.Active Barrier;
        public static Spell.Active Cleanse;
        public static Spell.Active Heal;
        public static Spell.Targeted Smite;
        public static Spell.Targeted Ignite;

        public static void Load()
        {
        }

        public static bool CheckBarrier()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("Barrier"))
            {
                Barrier = new Spell.Active(SpellSlot.Summoner1, 0);
            }
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("Barrier"))
            {
                Barrier = new Spell.Active(SpellSlot.Summoner2, 0);
            }

            if (Barrier == null)
            {
                return false;
            }else if(Barrier != null)
            {
                return true;
            }

            return false;
        }

        public static bool CheckCleanse()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("Cleanse"))
            {
                Cleanse = new Spell.Active(SpellSlot.Summoner1, 0);
            }
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("Cleanse"))
            {
                Cleanse = new Spell.Active(SpellSlot.Summoner2, 0);
            }

            if (Cleanse == null)
            {
                return false;
            }
            else if (Cleanse != null)
            {
                return true;
            }

            return false;
        }

        public static bool CheckHeal()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("Heal"))
            {
                Heal = new Spell.Active(SpellSlot.Summoner1, 0);
            }
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("Heal"))
            {
                Heal = new Spell.Active(SpellSlot.Summoner2, 0);
            }

            if (Heal == null)
            {
                return false;
            }
            else if (Heal != null)
            {
                return true;
            }

            return false;
        }

        public static bool CheckSmite()
        {
            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.ToLower()))
            {
                Smite = new Spell.Targeted(SpellSlot.Summoner1, 570);
            }
            else if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.ToLower()))
            {
                Smite = new Spell.Targeted(SpellSlot.Summoner2, 570);
            }

            if (Smite == null)
            {
                return false;
            }else if (Smite != null)
            {
                return true;
            }

            return false;
        }

        public static bool CheckIgnite()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("Dot"))
            {
                Ignite = new Spell.Targeted(SpellSlot.Summoner1, 500);
            }
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("Dot"))
            {
                Ignite = new Spell.Targeted(SpellSlot.Summoner2, 500);
            }

            if (Ignite == null)
            {
                return false;
            }else if (Ignite != null)
            {
                return true;
            }

            return false;
        }

        public static void UseCleanse()
        {
            CheckCleanse();

            if (ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse"))
                return;

            if (Player.Instance.HasBuffOfType(BuffType.Charm) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Charm"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Fear) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Fear"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Silence) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Silence"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Snare) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Snare"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Taunt) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Taunt"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Suppression) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Suppression"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Polymorph) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Polymorph"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Disarm) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Disarm"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.NearSight) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-NearSight"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Blind) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Blind"))
            {
                Cleanse.Cast();
            }

            if (Player.Instance.HasBuffOfType(BuffType.Sleep) || ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Cleanse-Sleep"))
            {
                Cleanse.Cast();
            }
        }

        public static void UseHeal()
        {
            CheckHeal();

            if (!ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Heal"))
                return;

            if (Player.Instance.HealthPercent <= ActivatorMenu.Slider(ActivatorMenu.Summoner, "Heal/01"))
            {
                Heal.Cast();
            }
        }

        public static void UseBarrier()
        {
            CheckBarrier();

            Barrier.Cast();
        }

        private static int SmiteDmg()
        {
            return new int[] {0, 390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000 }[Player.Instance.Level];
        }

        private static readonly string[] Monsters =
        {
            "SRU_Red", "SRU_Blue", "SRU_Dragon", "SRU_Baron", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak", "SRU_Krug", "Sru_Crab"
        };

        private static readonly string[] SmiteNames = 
        {
            "s5_summonersmiteplayerganker", "itemsmiteaoe", "s5_summonersmitequick", "s5_summonersmiteduel", "summonersmite"
        };

        public static void UseSmite()
        {
            CheckSmite();

            if (!ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Smite"))
                return;

            var Monster = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderBy(x => x.MaxHealth).Where(x => !x.Name.Contains("Mini")).FirstOrDefault(x => ActivatorMenu.CheckBox(ActivatorMenu.Summoner, x.BaseSkinName));

            if (Monster == null)
                return;

            if (Vector3.Distance(Player.Instance.ServerPosition, Monster.ServerPosition) <= Smite.Range)
            {
                if(Monster.Health <= SmiteDmg())
                {
                    Smite.Cast(Monster);
                }
            }

            if (!ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Smite/Ks"))
                return;

            var T = TargetSelector.GetTarget(Smite.Range, DamageType.True);

            if (T == null)
                return;

            if (!T.IsValid || T.IsDead)
                return;

            if(T.Health <= SmiteDmg())
            {
                Smite.Cast(T);
            }

        }

        private static int IgniteDmg()
        {
            return new int[] {0, 70, 90, 110, 130, 150, 170, 190, 210, 230, 250, 270, 290, 310, 330, 350, 370, 390, 410 }[Player.Instance.Level];
        }


        public static void UseIgnite()
        {
            CheckIgnite();


            Chat.Print(IgniteDmg());

            var T = TargetSelector.GetTarget(Ignite.Range, DamageType.True);

            if (!ActivatorMenu.CheckBox(ActivatorMenu.Summoner, "Ignite/" + T.ChampionName))
                return;

            if (T == null || T.IsDead || !T.IsValid)
                return;

            if(T.Health <= IgniteDmg())
            {
                Ignite.Cast(T);
            }
        }
    }
}
