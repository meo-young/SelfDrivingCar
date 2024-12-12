using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    private ObstacleDataManager obstacleData;

    private void Awake()
    {
        obstacleData = GetComponent<ObstacleDataManager>();
    }
    public bool IsObstacleInFront(float _detectionDistance)
    {
        // BoxCast의 충돌 정보 저장
        RaycastHit hit;
        Vector3 boxSize = new Vector3(8f, 5f, 5f);

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
            for(int i=0; i<obstacleData.GetObstacleTagList().Count; i++)
            {
                if (hit.collider.CompareTag(obstacleData.GetObstacleTagList()[i]))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
