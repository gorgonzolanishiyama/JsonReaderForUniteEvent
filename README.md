# JsonReaderForUniteEvent　Ver0.1.0.0
RPGMakerUniteのイベントデータ特化Jsonエディターです。
RPGMakerUniteで作成したイベントデータを直接編集することができます。


## 目次

1. [概要]
2. [使い方](#使い方)
3. [ビルド](#ビルド)

## 概要
RPGMakerUniteのイベントを、UnityやRPGMakerUniteを経由せずに編集できます。
※　数値や文字を強引に書き換えるので文字間違えでエラーが発生することがあり得ます。

イベントに対するお気に入り機能
ヘルプの作成機能もあります。


## 使い方
1.起動方法
そのままVisualStudio2022で開いて実行してください。
リリースビルドは行っていないです。

2.使ってみる  
2.1 UniteJsonEditer  
　    セーブ・ロードおよびイベントの基本情報が編集できます。(EventCommandFormへ)  
　    イベントコマンドは挿入等で操作できます。  
      お気に入りから挿入することができます。  
  
2.2 EventCommandForm
　　　イベントコマンドが編集できます。  
　　　また、ここで「お気に入り」に保存することでUniteJsonEditerで「お気に入り」として挿入することができます。(RegisterFavoritRventへ)  

　　　ヘルプテキストは変更可能です。  
　　　最初は仮のデータを載せているだけですが、別のテキストに編集可能です。  

　　　いい文章説明が出来たら西山に送ってください。  
  
2.3 RegisterFavoritEvent  
      概要を記載して、お気に入りを登録します。  
  
2.4 FavoriteList  
      2.3で決めた概要を選択します。  


## ビルド
VisualStudio2022で動くと思います。
多分。


