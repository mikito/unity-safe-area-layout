Unity Safe Area Layout
=======================

UnityのuGUIにてiOSのSafe Area対応を簡単に行うスクリプトです。　

使い方
---------

Canvas直下にSafeAreaという名前の新規ゲームオブジェクトを作成し、 SafeAreaLayoutスクリプトをアタッチします。

この時、自動的にRectTransformの設定が更新されます。

<img width="1280" alt="スクリーンショット 2019-08-25 1 00 42" src="https://user-images.githubusercontent.com/1071168/63639884-235a5600-c6d4-11e9-8bcd-562409f034e2.png">

セーフエリア内に収めたいUIをSafeAreaオブジェクト以下に配置します。

<img width="1280" alt="スクリーンショット 2019-08-25 1 00 21" src="https://user-images.githubusercontent.com/1071168/63639876-1473a380-c6d4-11e9-8bfa-2bf01851dbc0.png">

SafeAreaLayoutは実機端末のSafe Areaに応じて自動的にレイアウトを調整します。

レイアウトの確認
---------------
GameビューにてiPhone X系のアスペクトを選択することで、Safe Areaの領域が再現されます。これによりUnityエディター上でSafe Areaが適用されたレイアウトの確認ができます。

また、SafeAreaLayoutの領域が青い矩形で表示されるため、そちらを見ながらUIの調整が可能です。

<img width="1280" alt="スクリーンショット 2019-08-25 1 01 12" src="https://user-images.githubusercontent.com/1071168/63639861-e3936e80-c6d3-11e9-8fec-976614f43aef.png">

注意点
----------
* SafeAreaLayoutをネストさせることはできません。
* Canvasの直下、もしくはCanvasと同領域のRectTransformにアタッチする必要があります。
* World Space Canvasには対応していません。

