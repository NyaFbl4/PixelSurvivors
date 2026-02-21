using System;

namespace Project.Scripts.Systems.UI.Dtos
{
    public readonly struct ShowPopupDto
    {
        public Type PresenterType { get; }

        public ShowPopupDto(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}
