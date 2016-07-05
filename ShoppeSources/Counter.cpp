#include "Counter.h"


Counter::Counter(const int max) : MAX_COUNT(max)
{
	f_count = true;
	f_wrap  = true;
	counter = MAX_COUNT;
}


void Counter::Update()
{
	if (!f_count)	return;

	counter--;

	if(counter == 0 && f_wrap)	Reset();
}


void Counter::Reset(){
	counter = MAX_COUNT;
}


int Counter::Remainder(const int divisor){
	return counter % divisor;
}


int Counter::GetNowcount() {
	return counter;
}


void Counter::isCount(const bool f_count_){
	f_count = f_count_;
}


bool Counter::Last()
{
	if (counter > 1)	return false;
	return true;
}