using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class TestScriptNathan : MonoBehaviour
{
    public float updateFrequency = 5.0f;

    string json = @"{
        ""type"":""FeatureCollection"",""feed_info"":{""version"":""4.2"",""update_date"":""2024-09-06T18:03:39.443Z"",""publisher"":""PSS Innovations"",""contact_name"":""PSS Service Desk"",""contact_email"":""team@pss-innovations.com"",""license"":""https://creativecommons.org/publicdomain/zero/1.0/"",""data_sources"":[{""data_source_id"":""PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985"",""organization_name"":""unknown""}]},""features"":[{""id"":""ad:ea:f6:f9:3d:c9"",""type"":""Feature"",""properties"":{""core_details"":{""device_type"":""location-marker"",""data_source_id"":""PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985"",""device_status"":""ok"",""update_date"":""2024-09-06T18:01:29.000Z"",""has_automatic_location"":true,""status_messages"":[""{\""pss_extra_information\"":{\""state\"":\""ok\"",\""type\"":\""cone\""}}"",""Speed: 0.129000 hAcc: 70.200000 vAcc: 80.200000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -86""],""road_event_ids"":[""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""]},""marked_locations"":[{""type"":""delineator"",""road_event_id"":""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""}]},""geometry"":{""type"":""Point"",""coordinates"":[-86.042066845,39.746410018,2560.604]}},{""id"":""71:c0:cd:75:c6:d6"",""type"":""Feature"",""properties"":{""core_details"":{""device_type"":""location-marker"",""data_source_id"":""PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985"",""device_status"":""ok"",""update_date"":""2024-09-06T18:01:09.000Z"",""has_automatic_location"":true,""status_messages"":[""{\""pss_extra_information\"":{\""state\"":\""ok\"",\""type\"":\""cone\""}}"",""Speed: 0.164000 hAcc: 52.100000 vAcc: 69.900000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -86""],""road_event_ids"":[""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""]},""marked_locations"":[{""type"":""delineator"",""road_event_id"":""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""}]},""geometry"":{""type"":""Point"",""coordinates"":[-86.042017808,39.746486004,2560.987]}},{""id"":""71:99:31:a6:34:da"",""type"":""Feature"",""properties"":{""core_details"":{""device_type"":""location-marker"",""data_source_id"":""PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985"",""device_status"":""ok"",""update_date"":""2024-09-06T18:03:06.000Z"",""has_automatic_location"":true,""status_messages"":[""{\""pss_extra_information\"":{\""state\"":\""ok\"",\""type\"":\""cone\""}}"",""Speed: 0.024000 hAcc: 196.900000 vAcc: 271.000000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -69""],""road_event_ids"":[""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""]},""marked_locations"":[{""type"":""delineator"",""road_event_id"":""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""}]},""geometry"":{""type"":""Point"",""coordinates"":[-86.04201631,39.747006703,2585.086]}},{""id"":""23:b9:47:93:79:ca"",""type"":""Feature"",""properties"":{""core_details"":{""device_type"":""location-marker"",""data_source_id"":""PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985"",""device_status"":""ok"",""update_date"":""2024-09-06T18:02:44.000Z"",""has_automatic_location"":true,""status_messages"":[""{\""pss_extra_information\"":{\""state\"":\""ok\"",\""type\"":\""cone\""}}"",""Speed: 0.030000 hAcc: 552.900000 vAcc: 472.200000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -54""],""road_event_ids"":[""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""]},""marked_locations"":[{""type"":""delineator"",""road_event_id"":""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""}]},""geometry"":{""type"":""Point"",""coordinates"":[-86.042066617,39.747062655,2553.606]}},{""id"":""20:01:5a:f5:35:06"",""type"":""Feature"",""properties"":{""core_details"":{""device_type"":""location-marker"",""data_source_id"":""PSS-null"",""device_status"":""ok"",""update_date"":""2024-09-06T18:03:21.000Z"",""has_automatic_location"":true,""status_messages"":[""{\""pss_extra_information\"":{\""state\"":\""ok\"",\""type\"":\""homebase\""}}"",""Speed: 0.010000 hAcc: 16.100000 vAcc: 24.800000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: 0""],""road_event_ids"":[""PSS-a102af7c-f51d-4bc7-8bb5-26de26ce5344""]},""marked_locations"":[{""type"":""delineator""}]},""geometry"":{""type"":""Point"",""coordinates"":[-86.042071628,39.747096278,2570.031]}}]
    }";

    string json_1 = "";

    // Parse json
    [System.Serializable]
    public class FeatureCollection
    {
        public List<Feature> features;
    }

    [System.Serializable]
    public class Feature
    {
        public Geometry geometry;
    }

    [System.Serializable]
    public class Geometry
    {
        public string type;
        public List<float> coordinates; // Assuming coordinates are in float format
    }

    void Start()
    {
        InvokeRepeating("ConnectToWZDx", 0f, updateFrequency);
        //StartCoroutine(GetText_test());

    }

    void ConnectToWZDx()
    {
        Debug.Log("Trying to update.... at " + Time.time);
        StartCoroutine(GetText_test());
    }


    IEnumerator GetText_test()
    {
        // Show results as text
        string results = "{\"type\":\"FeatureCollection\",\"feed_info\":{\"version\":\"4.2\",\"update_date\":\"2024-09-21T21:58:36.596Z\",\"publisher\":\"PSS Innovations\",\"contact_name\":\"PSS Service Desk\",\"contact_email\":\"team@pss-innovations.com\",\"license\":\"https://creativecommons.org/publicdomain/zero/1.0/\",\"data_sources\":[{\"data_source_id\":\"PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985\",\"organization_name\":\"unknown\"}]},\"features\":[{\"id\":\"ad:ea:f6:f9:3d:c9\",\"type\":\"Feature\",\"properties\":{\"core_details\":{\"device_type\":\"location-marker\",\"data_source_id\":\"PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985\",\"device_status\":\"ok\",\"update_date\":\"2024-09-21T21:56:55.000Z\",\"has_automatic_location\":true,\"status_messages\":[\"{\\\"pss_extra_information\\\":{\\\"state\\\":\\\"ok\\\",\\\"type\\\":\\\"cone\\\"}}\",\"Speed: 0.044000 hAcc: 34.600000 vAcc: 51.600000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -90\"],\"road_event_ids\":[\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"]},\"marked_locations\":[{\"type\":\"delineator\",\"road_event_id\":\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"}]},\"geometry\":{\"type\":\"Point\",\"coordinates\":[-86.042056672,39.747701548,2554.527]}},{\"id\":\"71:c0:cd:75:c6:d6\",\"type\":\"Feature\",\"properties\":{\"core_details\":{\"device_type\":\"location-marker\",\"data_source_id\":\"PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985\",\"device_status\":\"ok\",\"update_date\":\"2024-09-21T21:56:49.000Z\",\"has_automatic_location\":true,\"status_messages\":[\"{\\\"pss_extra_information\\\":{\\\"state\\\":\\\"ok\\\",\\\"type\\\":\\\"cone\\\"}}\",\"Speed: 0.042000 hAcc: 53.600000 vAcc: 65.800000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -65\"],\"road_event_ids\":[\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"]},\"marked_locations\":[{\"type\":\"delineator\",\"road_event_id\":\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"}]},\"geometry\":{\"type\":\"Point\",\"coordinates\":[-86.042002556,39.747216451,2569.02]}},{\"id\":\"71:99:31:a6:34:da\",\"type\":\"Feature\",\"properties\":{\"core_details\":{\"device_type\":\"location-marker\",\"data_source_id\":\"PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985\",\"device_status\":\"ok\",\"update_date\":\"2024-09-21T21:58:31.000Z\",\"has_automatic_location\":true,\"status_messages\":[\"{\\\"pss_extra_information\\\":{\\\"state\\\":\\\"ok\\\",\\\"type\\\":\\\"cone\\\"}}\",\"Speed: 0.074000 hAcc: 62.100000 vAcc: 83.000000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -68\"],\"road_event_ids\":[\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"]},\"marked_locations\":[{\"type\":\"delineator\",\"road_event_id\":\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"}]},\"geometry\":{\"type\":\"Point\",\"coordinates\":[-86.042035193,39.74712845,2572.11]}},{\"id\":\"23:b9:47:93:79:ca\",\"type\":\"Feature\",\"properties\":{\"core_details\":{\"device_type\":\"location-marker\",\"data_source_id\":\"PSS-8f2be5a9-96f2-41a2-a365-c476a33a6985\",\"device_status\":\"ok\",\"update_date\":\"2024-09-21T21:56:34.000Z\",\"has_automatic_location\":true,\"status_messages\":[\"{\\\"pss_extra_information\\\":{\\\"state\\\":\\\"ok\\\",\\\"type\\\":\\\"cone\\\"}}\",\"Speed: 0.036000 hAcc: 37.000000 vAcc: 50.200000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: -81\"],\"road_event_ids\":[\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"]},\"marked_locations\":[{\"type\":\"delineator\",\"road_event_id\":\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"}]},\"geometry\":{\"type\":\"Point\",\"coordinates\":[-86.042023101,39.747614545,2554.837]}},{\"id\":\"20:01:5a:f5:35:06\",\"type\":\"Feature\",\"properties\":{\"core_details\":{\"device_type\":\"location-marker\",\"data_source_id\":\"PSS-null\",\"device_status\":\"ok\",\"update_date\":\"2024-09-21T21:58:22.000Z\",\"has_automatic_location\":true,\"status_messages\":[\"{\\\"pss_extra_information\\\":{\\\"state\\\":\\\"ok\\\",\\\"type\\\":\\\"homebase\\\"}}\",\"Speed: 0.011000 hAcc: 23.900000 vAcc: 32.500000, mqtt correction: 'pp/ip/L2N3875W08625/N3950W08650', RSSI: 0\"],\"road_event_ids\":[\"PSS-19bb9349-2d2f-4336-af69-9b7307728d25\"]},\"marked_locations\":[{\"type\":\"delineator\"}]},\"geometry\":{\"type\":\"Point\",\"coordinates\":[-86.042044613,39.747094598,2567.075]}}]}";
        Debug.Log(results);
        results = results.Substring(1, results.Length - 2);
        json_1 = string.Format(@"{{ {0} }}", results);
        print(json_1);
        // Or retrieve results as binary data
        //byte[] results = www.downloadHandler.data;

        // Deserialize the JSON string into the FeatureCollection class
        FeatureCollection featureCollection = JsonUtility.FromJson<FeatureCollection>(json_1);

        // Create data file for data
        long unixtime = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateTime est = DateTimeOffset.FromUnixTimeSeconds(unixtime).UtcDateTime.AddHours(-5);

        string filename = $"data_{unixtime}.csv";
        string filepath = Path.Combine(Environment.CurrentDirectory, filename);
        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.Write("Unix Time,EST,# of Features,Cone 1 X,Cone 1 Y,Cone 2 X," +
                "Cone 2 Y,Cone 3 X,Cone 3 Y,Cone 4 X, Cone 4 Y");
            writer.WriteLine();
            writer.Write($"{unixtime},{est},{featureCollection.features.Count - 1}");
        }

        int i = 0;
        // Loop through each feature to extract and print the coordinates
        foreach (var feature in featureCollection.features)
        {
            var coordinates = feature.geometry.coordinates;
            //Debug.Log($"Coordinate of Cone_{i}: {coordinates[0]}, {coordinates[1]}, {coordinates[2]}");
            //cones[i] = Map.GetComponent<OnlineMapsMarker3DManager>().Create(coordinates[0], coordinates[1], Prefab_Cone);
            //cones[i].scale = 40.0f;

            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.Write($"{coordinates[0]},{coordinates[1]}");
            }

            i++;

            if (i == 4)
            {
                break;
            }
        }

        yield return "Geofence Created";
    }
}
