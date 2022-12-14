namespace Snake
{
    public sealed class StatusKeeper
    {
        public StatusKeeper(ISnakeViewModel player, GameSettings settings, ListExecute listExecute)
        {
            var keeperModel = new KeeperModel(settings.StartSpeed);
            var keeperViewModel = new KeeperViewModel(keeperModel, player, settings);
            var keeperViewScore = new KeeperViewScore(keeperViewModel);
            var keeperViewSpeed = new KeeperViewSpeed(keeperViewModel);
            var keeperViewGameOver = new KeeperViewGameOver(keeperViewModel);
            listExecute.Add(keeperViewModel);
        }
    }
}
