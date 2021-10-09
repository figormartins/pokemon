import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:http/http.dart' as http;

class Carousel extends StatefulWidget {
  @override
  State<Carousel> createState() => _CarouselState();
}

class _CarouselState extends State<Carousel> {
  var response = '';

  var dio = Dio(BaseOptions(
    connectTimeout: 5000,
    receiveTimeout: 5000,
  ));

  @override
  void initState() {
    init();
    super.initState();
  }

  void init() async {
    response = await getImate();
  }

  @override
  Widget build(BuildContext context) {
    print(response.toString());

    return Container(
      color: Colors.red,
      // height: MediaQuery.of(context).size.height * 0.6 + 7,
      child: CarouselSlider(
        options: CarouselOptions(
          height: 500.0,
          aspectRatio: 2.0,
          enlargeCenterPage: true,
          initialPage: 0,
          scrollDirection: Axis.vertical,
        ),
        items: [1, 2, 3, 4, 5, 6].map((i) {
          print(i);
          return Builder(
            builder: (BuildContext context) {
              return Container(
                width: MediaQuery.of(context).size.width,
                margin: EdgeInsets.symmetric(horizontal: 5.0),
                decoration: BoxDecoration(color: Colors.amber),
                child: Image.network("https://10.0.2.2:5001/image/${i}"),
              );
            },
          );
        }).toList(),
      ),
    );
  }

  Future<String> getImate() async {
    try {
      var response = await dio.get('https://10.0.2.2:5001/image/1');
      return response.toString();
    } catch (e) {
      print(e);
      return "";
    }
  }
}
