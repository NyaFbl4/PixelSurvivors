namespace Project.Scripts.GameManager
{
    public interface IGameManagerService
    {
        public void StartGame();
        public void FinishGame();
        public void PauseGame();
        public void ResumeGame();
    }
}