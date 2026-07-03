using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine;

public class SceneRenderer
{
    private BasicEffect effect = null!;
    private VertexBuffer vertexBuffer = null!;
    private IndexBuffer indexBuffer = null!;
    private int indexCount;
    private float rotation;

    public void Initialize(GraphicsDevice graphicsDevice)
    {
        this.effect = new BasicEffect(graphicsDevice)
        {
            VertexColorEnabled = true,
        };

        this.BuildCube(graphicsDevice);
    }

    private void BuildCube(GraphicsDevice graphicsDevice)
    {
        VertexPositionColor[] vertices =
        [
            new(new Vector3(-1, -1,  1), Color.Red),
            new(new Vector3( 1, -1,  1), Color.Red),
            new(new Vector3( 1,  1,  1), Color.Red),
            new(new Vector3(-1,  1,  1), Color.Red),

            new(new Vector3( 1, -1, -1), Color.Green),
            new(new Vector3(-1, -1, -1), Color.Green),
            new(new Vector3(-1,  1, -1), Color.Green),
            new(new Vector3( 1,  1, -1), Color.Green),

            new(new Vector3(-1,  1,  1), Color.Blue),
            new(new Vector3( 1,  1,  1), Color.Blue),
            new(new Vector3( 1,  1, -1), Color.Blue),
            new(new Vector3(-1,  1, -1), Color.Blue),

            new(new Vector3(-1, -1, -1), Color.Yellow),
            new(new Vector3( 1, -1, -1), Color.Yellow),
            new(new Vector3( 1, -1,  1), Color.Yellow),
            new(new Vector3(-1, -1,  1), Color.Yellow),

            new(new Vector3( 1, -1,  1), Color.Orange),
            new(new Vector3( 1, -1, -1), Color.Orange),
            new(new Vector3( 1,  1, -1), Color.Orange),
            new(new Vector3( 1,  1,  1), Color.Orange),

            new(new Vector3(-1, -1, -1), Color.Purple),
            new(new Vector3(-1, -1,  1), Color.Purple),
            new(new Vector3(-1,  1,  1), Color.Purple),
            new(new Vector3(-1,  1, -1), Color.Purple),
        ];

        short[] indices =
        [
            0, 1, 2, 0, 2, 3,
            4, 5, 6, 4, 6, 7,
            8, 9, 10, 8, 10, 11,
            12, 13, 14, 12, 14, 15,
            16, 17, 18, 16, 18, 19,
            20, 21, 22, 20, 22, 23,
        ];

        this.vertexBuffer = new VertexBuffer(
            graphicsDevice,
            typeof(VertexPositionColor),
            vertices.Length,
            BufferUsage.WriteOnly);

        this.vertexBuffer.SetData(vertices);

        this.indexBuffer = new IndexBuffer(
            graphicsDevice,
            typeof(short),
            indices.Length,
            BufferUsage.WriteOnly);

        this.indexBuffer.SetData(indices);

        this.indexCount = indices.Length;
    }

    public void Update(GameTime gameTime)
    {
        this.rotation += (float)gameTime.ElapsedGameTime.TotalSeconds * 1.5f;
    }

    public void Draw(GraphicsDevice graphicsDevice)
    {
        graphicsDevice.Clear(Color.CornflowerBlue);

        this.effect.World = Matrix.CreateRotationY(this.rotation) * Matrix.CreateRotationX(this.rotation * 0.5f);
        this.effect.View = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);

        float aspectRatio = (float)graphicsDevice.Viewport.Width / graphicsDevice.Viewport.Height;
        if (float.IsNaN(aspectRatio) || aspectRatio <= 0.01f)
        {
            return;
        }

        this.effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.1f, 100f);

        graphicsDevice.SetVertexBuffer(this.vertexBuffer);
        graphicsDevice.Indices = this.indexBuffer;

        foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
        {
            pass.Apply();
            graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.indexCount / 3);
        }
    }
}
