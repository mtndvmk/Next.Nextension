﻿namespace Nextension
{
    public static class SceneRefExtension
    {
        public static string getPath(this SceneRef sceneRef)
        {
            return SceneRefPathManager.Getter.getScenePath(sceneRef);
        }
    }
}
