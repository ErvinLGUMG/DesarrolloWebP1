<?php

Route::get('/', 'BibliotecaController@index')->name('inicio');
//Route::get('/biblioteca')->name('prueba1');
Auth::routes();
Route::get('/Biblioteca/{id}/{name}/{tipo}', 'BibliotecaController@cursos')->name('biblioteca.inicio');

Route::get('/Biblioteca/Busqueda', 'BibliotecaController@store')->name('tipobusqueda');
Route::get('/Detalle/{id}', 'BibliotecaController@detalle')->name('detalle');

Route::get('/permisos','PermissionController@index')->name('permissions.index');
Route::get('/permisos/crear','PermissionController@create')->name('permissions.create');
Route::post('/permisos','PermissionController@store')->name('permissions.store');
Route::get('/permisos/{Name}','PermissionController@show')->name('permissions.show');
//--------------------------------------------------------------------------------------------
Route::resource('usuarios', 'UserController')->names('users');
Route::post('/usuarios/{id}', 'UserController@delete')->name('users.delete');
//--------------------------------------------------------------------------------------------
Route::resource('editoriales', 'EditorialController')->names('editorials');
Route::post('/editoriales/{id}', 'EditorialController@delete')->name('editorials.delete');
//--------------------------------------------------------------------------------------------
Route::get('/reporte/autores', 'ReportController@authors')->name('reports.authors');
Route::get('/reporte/categorias', 'ReportController@categories')->name('reports.categories');




Route::get('/roles','RolController@index')->name('roles.index');
Route::post('/roles/crear','RolController@store')->name('roles.store');
Route::get('/roles/{Name}','RolController@show')->name('roles.show');

Route::post('/autores','AuthorController@store')->name('authors.store');
Route::put('/autores','AuthorController@storeEdit')->name('authors.update');
Route::get('/autores','AuthorController@eliminar')->name('authors.eliminar');
Route::get('/autores/crear','AuthorController@create')->name('authors.create');
Route::get('/autores/editar','AuthorController@createEdit')->name('authors.edit');
Route::get('/autores/borrar','AuthorController@delete')->name('authors.delete');

Route::post('/libros','BookController@store')->name('books.store');
Route::post('/libros','BookController@storeEdit')->name('books.update');
Route::get('/libros','BookController@eliminar')->name('books.eliminar');
Route::get('/libros/crear','BookController@create')->name('books.create');
Route::get('/libros/editar','BookController@createEdit')->name('books.edit');
Route::get('/libros/borrar','BookController@delete')->name('books.delete');

Route::post('/signIn','SignInController@store')->name('signIn');
//Route::get('/signIn','SignInController@store')->name('loginStore');
