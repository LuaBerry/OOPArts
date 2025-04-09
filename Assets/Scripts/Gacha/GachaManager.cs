using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GachaManager : MonoBehaviour
{
    public void RequestGacha(string playerId, int gachaType)
    {
        // GachaRequest를 통해 서버에 요청을 보냄
        string json = "";
        // 서버와 통신하여 결과를 받음 (예: 코루틴 사용)
        StartCoroutine(SendGachaRequest(json));
    }
    [System.Serializable]
    public class GachaResult
    {
        public string characterId;
        public int rarity;
    }
    
    private IEnumerator SendGachaRequest(string json)
    {
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        string serverUrl = "";
        // 서버 URL (예시)
        string url = "https://example.com/gacha"; // 실제 서버 URL로 변경해야 함
        // UnityWebRequest를 사용하여 POST 요청을 보냄
        UnityWebRequest request = new UnityWebRequest(serverUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        // 서버와 통신하는 부분 (예: UnityWebRequest 사용)
        // 예시로 2초 대기 후 결과를 받는다고 가정
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            Debug.Log("서버 응답: " + response);

            // JSON 파싱
            GachaResult result = JsonUtility.FromJson<GachaResult>(response);
            Debug.Log($"뽑은 캐릭터: {result.characterId}, {result.rarity}성");
        }
        else
        {
            Debug.LogError("요청 실패: " + request.error);
        }

    }
}
