using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.DamageLib;
using EnsoulSharp.SDK.MenuUI.Values;
using EnsoulSharp.SDK.Prediction;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;

namespace CybernautVayne
{
    public class Program

    {
        private static Menu MainMenu;

        private static Spell Q;
        private static Spell E;
        private static Spell R;
        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad()
        {
            if (ObjectManager.Player.CharacterName != "Vayne")
            {
                return;
            }

            Q = new Spell(SpellSlot.Q, 300f);

            E = new Spell(SpellSlot.W, 550f);
            E.SetTargetted(0.25f, float.MaxValue);

            MainMenu = new Menu("cybervayne", "Cyber Vayne", true);

            var comboMenu = new Menu("Combo", "Combo Settings");
            comboMenu.Add(new MenuBool("comboQ", "Use Q", true));
            comboMenu.Add(new MenuBool("comboW", "Use W", true));
            comboMenu.Add(new MenuBool("comboE", "Use E", true));
            comboMenu.Add(new MenuBool("comboR", "Use R", true));
            MainMenu.Add(comboMenu);

            var laneclearMenu = new Menu("Lane", "Lane Clear Settings");
            laneclearMenu.Add(new MenuBool("laneQ", "Use Q", true));
            MainMenu.Add(laneclearMenu);

            var lasthitMenu = new Menu("Last", "Last Hit Settings");
            lasthitMenu.Add(new MenuBool("lastQ", "Use Q"));
            MainMenu.Add(lasthitMenu);

            var jungleclearMenu = new Menu("jungle", "Jungle Clear Settings");
            jungleclearMenu.Add(new MenuBool("jungleQ", "Use Q"));
            MainMenu.Add(jungleclearMenu);

            var drawMenu = new Menu("Draw", "Draw Settings");
            drawMenu.Add(new MenuBool("drawQ", "Draw Q Range"));
            drawMenu.Add(new MenuBool("drawE", "Draw E Range"));
            MainMenu.Add(drawMenu);

            MainMenu.Add(new MenuBool("isDead", "if Player is Dead not Draw Range"));

            MainMenu.Attach();

            
        }
        private static void Combo()
        {
            if (MainMenu["Combo"]["comboQ"].GetValue<MenuBool>().Enabled && Q.IsReady())
            {
                {
                    var target = TargetSelector.GetTarget(Q.Range);

                    if (target != null && target.IsValidTarget(Q.Range))

                    {
                        Q.Cast(Game.CursorPosRaw);
                    }
                }
                {
                    if (MainMenu["Combo"]["comboE"].GetValue<MenuBool>().Enabled && E.IsReady())
                    {
                        ;
                        var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                        {
                            if (target != null && target.IsValidTarget(E.Range))
                            {
                                ;
                            }
                        }
                    }                 
                }
            }
        }
    }
}
        
    

