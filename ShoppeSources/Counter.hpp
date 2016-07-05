#pragma once


/*
�J�E���^�[���悭�g���̂ō��܂����B
���炩�ɁuTimer�v���Ă������O�ɂ̂ق����ǂ��B�Ȃ��Ȃ猸�Z�`��������B
*/
class Counter
{
private:
	// �J�E���^�[�̍ő�ω���
	const int  MAX_COUNT;

	// �J�E���^�[
	int  counter;
	
	// �J�E���g���邩�ǂ���
	bool f_count;
	
	// �O�ɂȂ����㏟��Ƀ��Z�b�g���邩�ǂ���
	bool f_wrap;

private:
	// ���ʂ̃R���X�g���N�^�͎g���Ă͂����܂���
	Counter       ();

public:
	// �J�E���g����ő�t���[�����������ɂ���
	Counter          (const int  max);
	~Counter         () {}

	// ���ꂪ�Ă΂��x�ɃJ�E���g�_�E�����܂�
	void Update      ();

	// �����ƌ��݂̃J�E���g�����������܂��Ԃ��܂��B
	int  Remainder   (const int  divisor);

	// ���݂̃J�E���g��Ԃ��܂�
	int  GetNowcount ();
	
	// �J�E���g���邩�ǂ�����؂�ւ���
	void isCount     (const bool f_count_);
	
	// ���݂̃J�E���^�[�������l�ɖ߂��܂�
	void Reset       ();
	
	// �Ō�̃J�E���g�ɂȂ������ǂ���
	bool Last        ();
};