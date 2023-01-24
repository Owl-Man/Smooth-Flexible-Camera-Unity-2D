# Smooth-Flexible-Camera-Unity-2D
### The camera control script should be on a camera that will move smoothly with the player (or any other object).

In the **Player** parameter, you need to specify the transform of the object that the camera will follow.

In the parameters **leftLimit**, **rightLimit**, **bottomLimit** and **upperLimit**, you need to specify the values up to which the camera can move and, having reached this limit, smoothly stop (if you do not need to limit the movement of the camera, just set the boolean value hasLimit to false).

In the **Offset** parameter, you need to specify two values x and y, with which you can specify how smoothly the camera should stop. That is, when the object stops, the larger the value, the longer the camera will continue to move smoothly stopping. (balance values are set by default).

The **Dumping** parameter specifies the smoothness of the camera. The larger this value, the more abruptly the camera will stop and the smaller the value, the smoother (balance values are set by default).
