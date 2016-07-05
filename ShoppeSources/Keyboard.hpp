#pragma once

// キーの入力状態を更新する // Main内に１つだけ置いてください
void Keyboard_Update();

// 引数のキーコードのキーの入力状態を返す
int Keyboard_Get(int KeyCode);