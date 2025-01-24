# ■easymirror使用方法（Ver0.6.1）
![コメント 2024-12-06 123058](https://github.com/user-attachments/assets/b250c3f9-1751-4e17-b27d-9b66f0e006f1)

## ■はじめに

このアプリはScrcpyをGUIで制御し、Androidスマートフォンの画面をPCに
映すミラーリングアプリとなっています。（Scrcpyの外部ツール的な立ち位置）
ボイスチャットなどでスマホゲームをしながら画面共有
を行ったり録画した画面を編集してみてください。

　また、一人で開発しているため
どんなバグが出るかが未知数です（やばそうなバグは潰しましたが）
もしアプリの挙動がおかしいと感じたら臆せずタスクマネージャー
から「easymirror」と「adb.exe」（無ければ大丈夫です）のアプリを
強制終了させてください。

　このアプリはスマートフォン側でUSBデバックを有効にする必要が
ありますのでご了承ください。
USBデバッグについては別記載の「USBデバック起動方法」をご確認ください。

スマホからの音声出力はAndroid11(API >= 30)以上で対応しています。

　最後にアンケートのご記入をお願いします。
動作環境やどんなバグが出たかを確認するためのアンケートですので
ご協力お願いします。
※qrコードを配布しています


# ■動作環境
<pre>
PC
 ・Windows10 22H2
 ・Windows11

スマートフォン（必要要件）
 ・Android5(API >= 21)以上
 ・CPU(SoC):1.8GHz以上
 ・メモリ: 3GB以上

</pre>

# ■起動方法
easymirror.exeを開くとスタート画面が開きます。

# ■機能説明
#  MainWindow
    1かんたんスタート
        MirorrAppが開始されコントローラーと
        スマホ画面が表示されます。

    2録画フォルダ
        録画やスクリーンショットをしたファイルを
        閲覧することができます。

    3カスタマイズ
        CustomSettingWindowに移動します。
        easymirrorを起動する際に詳細な設定を行うことができます。      
# Controller
![コメント 2024-12-06 123126](https://github.com/user-attachments/assets/510ff3fb-38de-4e3e-866a-30b8393e36bb)


    スマホ画面が表示された際にコントローラーを表示しカスタマイズを行える画面

    1全画面表示ボタン（アイコン）
        全画面表示が行える

    2録画ボタン
        画面の録画を行える
    
    3スクリーンショットボタン
        画面のスクリーンショットが行える
	
    4 AVミュートボタン
	一時的にミラーリング画面と音声を遮断します。

    5カスタマイズボタン
	MainWindowにあるボタンと同様コントローラーから
	CustomSettingWindowに遷移する。
 
    6フォルダーボタン
    	保存した録画やスクリーンショットを閲覧することができます。

    
    ※全画面ボタンと録画ボタンは既定の値を
    　返すようになっているためカスタマイズ機能で入れた値は反映されません。


# CustomSettingWindow
![コメント 2024-12-06 124657](https://github.com/user-attachments/assets/794ea885-68fd-4d14-85b9-d05874608f24)

    easymirrorを起動する際に詳細な設定を行うことが
    できます。
    各種設定を行ってから「カスタマイズスタート」を押すと
    設定が反映されスマホ画面が表示されます。

    1無線起動
        チェックを入れると無線での起動を行える
	    初回起動はUSB接続が必要です。
        
    
    2各種入力箇所
        最大FPS,ビットレート,ビデオバッファ、最大サイズの
        変更を数値で行える。
    
    3録画機能
        チェックを入れることで録画を開始できる

    4コーデック選択
        映像・音声コーデックの変更ができる
        音声を出さないことも可能
    
    5画面サイズの変更
        画面サイズの変更が可能

    6無線接続切断
        無線接続からの切断をします
       ※無線接続をしている場合にボタンが押せるようにしています
         有線に戻したい場合に使用してください。

    ※0や何も記載がない場合はデフォルトの値を
    　返すようにしています

    最大FPS　      60fps
    ビットレート　  8M
    ビデオバッファ  0ms
    最大サイズ     1024px

## ■使用ライブラリ・素材
app
- scrcpy  
https://github.com/Genymobile/scrcpy

## ■免責
作者は、このソフトによって生じた如何なる損害にも、  
修正や更新も、責任を負わないこととします。  
使用にあたっては、自己責任でお願いします。 

何かあれば[アンケートフォーム](https://forms.gle/xqppvi1PdnVyThGj7)か、githubの[issues](https://github.com/na-tu0227/easymirror/issues)までお願いします。


## ■著作権表示
Copyright (C) 2024 na_tu0227

自分が書いた部分のソースコードは、MIT Licenseとします。

## ■更新状況
<pre>
ver0.6.2
・[fix]Scrcpyのバージョンを3.1に更新
・[fix]複数の端末が接続されているとスクリーンショットがうまく機能しない不具合を修正
・[refactor]CommandList.jsonにスクリーンショットコマンドを追加
・[fix]カスタマイズ→コントローラーに戻りスクリーンショットボタンを押すとアプリがクラッシュする不具合を修正
ver0.6.1
・[docs]Readme更新
・[feat]画面デザイン一部変更。ボタンの拡大とテキスト変更。
・[fix]カスタマイズ機能で設定した数値を引き継いだままコントローラーで全画面表示や録画ができるように修正。
・[refactor]ファイルパスとカスタマイズ機能で使用する変数の格納場所を変更（ファイルパス:MainDTO、カスタマイズ変数:CustomDTO）
ver0.6
・[fix]Scrcpyのバージョンを3.0に更新
・[fix]ウィンドウ画面を固定するように修正。
・[feat]log.txtを追加
ver0.5.2
・[fix] カスタマイズ機能、「録画を開始する」と「全画面表示をする」にチェックを入れると、どちらも停止できない状況になるため録画を停止できるように修正。
ver0.5.1 
・[docs]Readme更新
・[feat]録画をしている時に録画アイコンを表示するように変更。
・[fix refactor] 無線機能のソースコードをリファクタリングの実施。WirelessProcからプロセスを呼び出していたのをMainProcで呼び出すように修正、nullチェックも無くなる。
・[fix]スクリーンショット撮影方法変更adbコマンドで画像のバイナリーデータを取得し保存する。
・[fix]録画ファイル名称変更[MirrorApp] → [easymirror]
ver0.5
・ベータ版公開

</pre>












