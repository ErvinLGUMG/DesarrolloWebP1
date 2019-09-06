<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class UserController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/ListUsers');
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
         $response = $client->post('40.117.209.118/libraryapi/api/Security/CreateUser', [
            'body'=>json_encode([
                'UserId' => request('id'),
                'Name' => request('name'),
                'Password' => request('pass'),
                'Email' => request('email'),
                'Telephone' => request('phone'),
                'State' => request('state')
            ])
         ]);
        // return $response->getBody();
         return redirect()->route('users.index');
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($UserId)
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/User?UserId='.$UserId);
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

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
}
