<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('index');
});

Route::get('/permisos','PermissionController@index')->name('permissions.index');
Route::get('/permisos/crear','PermissionController@create')->name('permissions.create');
Route::post('/permisos','PermissionController@store')->name('permissions.store');
Route::get('/permisos/{Name}','PermissionController@show')->name('permissions.show');

Route::get('/usuarios','UserController@index')->name('users.index');
Route::post('/usuarios','UserController@store')->name('users.store');
Route::get('/usuarios/crear','UserController@create')->name('users.create');
Route::get('/usuarios/{Name}','UserController@show')->name('users.show');

Route::get('/roles','RolController@index')->name('roles.index');
Route::post('/roles/crear','RolController@store')->name('roles.store');
Route::get('/roles/{Name}','RolController@show')->name('roles.show');

Route::post('/autores','AuthorController@store')->name('authors.store');
Route::get('/autores/crear','AuthorController@create')->name('authors.create');

Route::post('/libros','BookController@store')->name('books.store');
Route::get('/libros/crear','BookController@create')->name('books.create');


