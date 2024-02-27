using System;
using System.Collections.Generic;

namespace ASoldiersWar
{
    public class AnimationManager
    {
        private readonly Dictionary<object, Animation> _animations = new Dictionary<object, Animation>();
        private object _lastKey;

        public void AddAnimation(object key, Animation animation)
        {
            _animations.Add(key, animation);
            _lastKey ??= key;
        }

        public void Update(object key)
        {
            if (_animations.TryGetValue(key, out Animation value))
            {
                value.Start();
                _animations[key].Update();
                _lastKey = key;
            }

            else
            {
                _animations[_lastKey].Stop();
                _animations[_lastKey].Reset();
            }
        }
    }
}
