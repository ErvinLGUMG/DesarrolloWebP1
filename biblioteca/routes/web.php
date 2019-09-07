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

Route::get('/', 'BibliotecaController@index')->name('inicio');
Route::get('/Biblioteca/{id}/{name}/{tipo}', 'BibliotecaController@cursos')->name('biblioteca.inicio');

Route::post('/Biblioteca/Busqueda', 'BibliotecaController@store')->name('tipobusqueda');
//Route::get('/Biblioteca/busqueda', 'BibliotecaController@busqueda' )->name('busqueda');

Route::get('/permisos','PermissionController@index')->name('permissions.index');
Route::get('/permisos/crear','PermissionController@create')->name('permissions.create');
Route::post('/permisos','PermissionController@store')->name('permissions.store');
Route::get('/permisos/{Name}','PermissionController@show')->name('permissions.show');

//--------------------------------------------------------------------------------------------
Route::resource('usuarios', 'UserController')->names('users');
//--------------------------------------------------------------------------------------------
Route::resource('editoriales', 'EditorialController')->names('editorials');
//--------------------------------------------------------------------------------------------

Route::get('/roles','RolController@index')->name('roles.index');
Route::post('/roles/crear','RolController@store')->name('roles.store');
Route::get('/roles/{Name}','RolController@show')->name('roles.show');

Route::put('/autores','AuthorController@storeEdit')->name('authors.update');
Route::post('/autores','AuthorController@store')->name('authors.store');
Route::get('/autores/crear','AuthorController@create')->name('authors.create');
Route::get('/autores/editar','AuthorController@createEdit')->name('authors.edit');


Route::post('/libros','BookController@store')->name('books.store');
Route::post('/libros','BookController@storeEdit')->name('books.update');
Route::get('/libros/crear','BookController@create')->name('books.create');
Route::get('/libros/editar','BookController@createEdit')->name('books.edit');

Route::post('/signIn','SignInController@store')->name('signIn');
//Route::get('/signIn','SignInController@store')->name('loginStore');

Auth::routes();
