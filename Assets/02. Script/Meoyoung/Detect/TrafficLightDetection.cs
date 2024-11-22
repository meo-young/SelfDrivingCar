using UnityEngine;

public class TrafficLightDetection : MonoBehaviour
{
    public bool IsTrafficLightInFront(float _detectionDistance)
    {
        // BoxCast의 충돌 정보 저장
        RaycastHit hit;
        Vector3 boxSize = new Vector3(8f, 5f, 20f);

        // 전방으로 BoxCast 실행
        if (Physics.BoxCast(
            transform.position,                      // 시작 지점
            boxSize,                             // Box 크기
            transform.forward,                       // 방향
            out hit,                                 // 충돌 정보 출력
            transform.rotation,                      // Box의 회전값
            _detectionDistance                        // 감지 거리
            ))        
        {
            if (hit.collider.CompareTag("TrafficLight"))
            {
                return true;
            }
        }

        return false;
    }

    public bool HasToStop()
    {
        // 신호등 빨간 불인지 판단하는 로직
        return false;
    }
}
