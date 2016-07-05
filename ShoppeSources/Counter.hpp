#pragma once


/*
カウンターをよく使うので作りました。
明らかに「Timer」っていう名前にのほうが良い。なぜなら減算形式だから。
*/
class Counter
{
private:
	// カウンターの最大変化量
	const int  MAX_COUNT;

	// カウンター
	int  counter;
	
	// カウントするかどうか
	bool f_count;
	
	// ０になった後勝手にリセットするかどうか
	bool f_wrap;

private:
	// 普通のコンストラクタは使ってはいけません
	Counter       ();

public:
	// カウントする最大フレーム数を引数にする
	Counter          (const int  max);
	~Counter         () {}

	// これが呼ばれる度にカウントダウンします
	void Update      ();

	// 引数と現在のカウントを割ったあまりを返します。
	int  Remainder   (const int  divisor);

	// 現在のカウントを返します
	int  GetNowcount ();
	
	// カウントするかどうかを切り替える
	void isCount     (const bool f_count_);
	
	// 現在のカウンターを初期値に戻します
	void Reset       ();
	
	// 最後のカウントになったかどうか
	bool Last        ();
};