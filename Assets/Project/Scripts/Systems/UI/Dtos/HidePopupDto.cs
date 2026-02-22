using System;

namespace Project.Scripts.Systems.UI.Dtos
{
    public readonly struct HidePopupDto
    {
        public Type TargetPopUpType { get; }

        public HidePopupDto(Type presenterType)
        {
            TargetPopUpType = presenterType;
        }
    }
}
