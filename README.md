The example shows how to create and use [texture shader](https://github.com/Naninovel/CustomShader/blob/main/Assets/Shaders/CustomTexture.shader) for adding custom transition effects and [sprite shader](https://github.com/Naninovel/CustomShader/blob/main/Assets/Shaders/CustomSprite.shader) with lighting and self-illumination support; the latter is used to simulate time of day for a background actor.

![](https://i.gyazo.com/227ea4bfbe540506bb815c8001869b40.gif)

Background texture has self-illumination mask stored in the alpha layer, which is used by the custom shader to evaluate which areas should emit light, while ignoring the global light.

![](https://i.gyazo.com/9cd8895731925267eab898ceeddb76a7.gif)

Documentation: https://naninovel.com/guide/custom-actor-shader

Be aware, that Naninovel package is not distributed with the project, hence compilation errors will be produced after opening it for the first time; import Naninovel from the Asset Store to resolve the issues.

If you have any questions or issues, [contact the support](https://naninovel.com/support/).
