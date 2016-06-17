<?php

Route::get('/', 'HomeController@index');
Route::get('user', 'StatsController@stats');
Route::get('user/{id}', 'StatsController@statsIncrement');
Route::get('townhall', 'StatsController@townhall');

Route::get('arena', 'BattleController@arena');
Route::post('reward', 'BattleController@reward');
Route::get('raid', 'BattleController@raid');

Route::get('shop', 'ShopController@index');
Route::get('shop/{img}/{type}/{name}/{att}/{price}', 'ShopController@buy');

Route::controllers([
	'auth' => 'Auth\AuthController',
	'password' => 'Auth\PasswordController',
]);


// Test routes
Route::get('test', 'WelcomeController@test');
Route::get('welcome', 'WelcomeController@index');


