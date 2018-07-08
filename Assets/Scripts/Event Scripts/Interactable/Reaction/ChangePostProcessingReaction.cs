using UnityEngine;
using UnityEngine.PostProcessing;
public class ChangePostProcessingReaction : DelayedReaction
{
    public PostProcessingProfile profile;

    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_PostProcessingBehaviour.ChangePostProcessingProfile(profile);
    }
}
