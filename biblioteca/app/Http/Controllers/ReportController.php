<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class ReportController extends Controller
{

    public function authors(){
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Document/ListAuthor');
        $authors = $request->getBody();
        $authors = json_decode($authors);

        return view('reports.authors',['authors' => $authors]);
        // dd($authors);
    }

    public function categories(){
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Document/ListCategory');
        $categories = $request->getBody();
        $categories = json_decode($categories);

        return view('reports.categories',['categories' => $categories]);

    }

}
