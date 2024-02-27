using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ASoldiersWar
{
    public class Animation
    {
        private readonly Texture2D _texture;
        private readonly List<Rectangle> _sourceRectangles = new List<Rectangle>();
        private readonly int _frameAmount;
        private int _currentFrame;
        private readonly float _frameTime;
        private float _frameTimeRemaining;
        private bool _isPlaying = true;

        public Animation(Texture2D texture, int framesX, int framesY, float frameTime, int row = 1)
        {
            _texture = texture;
            _frameAmount = framesX;
            _frameTime = frameTime;
            _frameTimeRemaining = _frameTime;
            var frameWidth = _texture.Width/framesX;
            var frameHeight = _texture.Height/framesY;

            for (int i = 0; i < _frameAmount; i++)
            {
                _sourceRectangles.Add(new(i*frameWidth, (row - 1) * frameHeight, frameWidth, frameHeight));
            }
        }

        public void Stop()
        {
            _isPlaying = false;
        }

        public void Start()
        {
            _isPlaying = true;
        }

        public void Reset()
        {
            _currentFrame = 0;
            _frameTimeRemaining = _frameTime;
        }

        public void Update()
        {
            if (!_isPlaying)
            {
                return;
            }

            _frameTimeRemaining -= Globals.TotalSeconds;

            if (_frameTimeRemaining <= 0)
            {
                _frameTimeRemaining += _frameTime;
                _currentFrame = (_currentFrame + 1 ) % _frameAmount;
            }
        }

        public void Draw(Vector2 pos)
        {
            Globals.SpriteBatch.Draw(_texture, pos, _sourceRectangles[_currentFrame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
