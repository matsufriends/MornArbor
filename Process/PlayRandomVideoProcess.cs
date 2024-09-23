using Arbor;
using UnityEngine;
using UnityEngine.Video;

namespace MornArbor.Process
{
    public class PlayRandomVideoProcess : ProcessBase
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private VideoClip[] _clips;
        public override float Progress
        {
            get
            {
                if (_videoPlayer)
                {
                    if (_videoPlayer.frame > 0 && !_videoPlayer.isPlaying)
                    {
                        return 1;
                    }
                    return Mathf.Clamp01(_videoPlayer.frame / (float)_videoPlayer.frameCount);
                }

                return 1f;
            }
        }

        public override void OnStateBegin()
        {
            _videoPlayer.clip = _clips[Random.Range(0, _clips.Length)];
            _videoPlayer.Play();
        }
    }
}