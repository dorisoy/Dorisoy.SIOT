# Dorisoy.SIOT

一款.Net8.0下使用 MAUI 框架开发的跨平台牙科治疗机物联网移动端应用程序，实现了水温检测[Speedometer](https://github.com/search?q=maui-radialgauge&type=repositories)，高速手机转速[radial gauge](https://github.com/search?q=maui-Speedometer&type=repositories)，电动马达功率，光纤灯光亮度调节等数据采集的仪表盘数据监测，并实现数据采集的可视化检测和远程控制。


# Android屏幕

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/12.jpg" align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/11.jpg" align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/10.jpg" width="260"/>

##

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/9.jpg"  align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/8.jpg"  align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/7.jpg"  width="260"/>

##

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/6.jpg"  align="left" width="260" vspace="20"/>
<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/5.jpg"  align="left" width="260" vspace="20"/>
<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/4.jpg"  width="260"/>

##

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/3.jpg"  align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/2.jpg"  align="left" width="260" vspace="20"/>

<img src="https://github.com/dorisoy/Dorisoy.SIOT/blob/main/Screen/1.jpg"  width="260"/>

# 设计方案

  ### 1.功能需求/模块划分

  数据采集模块：与物联网设备通信，获取牙科治疗机的实时数据。
  数据处理模块：处理从物联网设备接收到的数据，并进行分析、转换。
  可视化展示模块：将处理后的数据以图表、图形等形式展示在应用程序界面上，以供用户清晰地查看治疗数据。
  远程控制模块：允许用户通过应用程序远程控制牙科治疗机的参数设置和操作。

   ### 2.技术选型
  
  MAUI 框架：采用 MAUI 跨平台框架，实现单一代码库在 iOS、Android 和 Windows 上运行应用程序。
  物联网通信：使用 MQTT 或 WebSocket 进行设备间通信。
  数据可视化：使用 Xamarin.Forms 中的图表控件或第三方图表库实现数据可视化展示。
  远程控制：通过 RESTful API 或 WebSocket 实现远程设备控制。

   ### 3.架构设计
  
  MVVM 架构：使用 MVVM（Model-View-ViewModel）架构模式，将业务逻辑和 UI 逻辑分离，提高代码的可测试性和可维护性。
  模块化设计：将不同功能模块分解为独立的组件，实现代码复用和易于管理的结构。
  
   ### 4.用户界面设计
  
  数据展示页面：展示牙科治疗机的实时数据，包括图表展示以及数据列表。
  远程控制页面：允许用户调整牙科治疗机的参数、启动/停止治疗等操作。
  用户权限管理：可对用户权限进行管理，包括登录认证、用户角色权限设置等功能。
  
   ### 5.安全与隐私
  
  数据加密：对传输的治疗机数据进行加密，确保数据安全传输。
  用户认证：实现用户登录认证机制，保护用户隐私信息和数据安全。
  数据安全存储：对本地存储的数据进行加密和权限控制。



  ## 微信扫码交流

![](https://github.com/dorisoy/Wesley/blob/main/weixing.png?raw=true)
