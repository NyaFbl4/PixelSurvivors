using System;

namespace Project.Scripts.Systems.UI.Dtos
{
    public readonly struct HidePopupDto
    {
        public Type PresenterType { get; }

        public HidePopupDto(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}
