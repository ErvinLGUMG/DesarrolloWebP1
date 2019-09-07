<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class UserController extends Controller
{

    public function __construct(){
        $this->middleware('admin');
    }

    public function index()
    {
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Security/ListUsers');
        $users = $request->getBody();

        return view('users.index',['users' => json_decode($users)]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        return view('users.create');
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
         ]);
         $response = $client->post('34.217.191.19/libraryapi/api/Security/CreateUser', [
            'body'=>json_encode([
                'UserId' => request('id'),
                'Name' => request('name'),
                'Password' => request('pass'),
                'Email' => request('email'),
                'Telephone' => request('phone'),
                'State' => 1
            ])
         ]);

        return back()->with('status','El usuario ha sido creado');
    }


    public function show($UserId)
    {
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Security/User?UserId='.$UserId);
        $users = $request->getBody()->getContents();

        $users = json_decode($users);
        foreach ($users as $value) {
            foreach ($value as  $user) {
                $data = $user;
            }
        }
        $user = $data;
        return view('users.show', compact('user'));
    }

    public function edit($id)
    {
        return view('users.edit',['id'=>$id]);
    }

    public function update($id)
    {
        $body = json_encode([
            'UserId' => $id,
            'Name' => request('name'),
            'Email' => request('email'),
            'Telephone' => request('phone'),
        ]);

        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('34.217.191.19/libraryapi/api/Security/UpdateUser', [
            'body'=>$body
        ]);
        return redirect()->route('users.edit')->with('status','El usuario ha sido creado');
        // return $body;
    }

    public function delete($id)
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('http://34.217.191.19/LibraryApi/api/Security/ChangeStateUser?UserId='.$id.'&State=false', [
        ]);

        return redirect()->route('users.index');
    }
}
