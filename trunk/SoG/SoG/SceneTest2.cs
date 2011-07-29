using System;
using System.Collections.Generic;
using Esmeralda.Framework;
using Esmeralda.Graphics;
using Esmeralda.Input;

namespace SoG
{
    class SceneTest2 : SceneBase
    {
        protected override void Start()
        {
            this.objects.Add("caja", new SpriteBase(Cache.Load("MAPS", "box")));
        }

        protected override void Update()
        {
            base.Update();
            if (Keyboard.Trigger(Keys.RETURN))
            {
                SetScene(new SceneTest());
            }
        }
    }
}
