using Microsoft.Xna.Framework;
using MonoGame.Framework.WpfInterop;
using Engine;

namespace Core;

public class EditorGame : WpfGame
{
    private SceneRenderer sceneRenderer = null!;

    protected override void Initialize()
    {
        // NOTE: WpfGraphicsDeviceService must be created before base.Initialize
        _ = new WpfGraphicsDeviceService(this);
        base.Initialize();

        this.sceneRenderer = new SceneRenderer();
        this.sceneRenderer.Initialize(this.GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        this.sceneRenderer.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.sceneRenderer.Draw(this.GraphicsDevice);
    }
}


