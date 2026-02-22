using System;

namespace Project.Scripts.Systems.UI.Dtos
{
    public readonly struct ShowPopupDto
    {
        public Type TargetPopUpType { get; }

        public ShowPopupDto(Type presenterType)
        {
            TargetPopUpType = presenterType;
        }
    }
}
